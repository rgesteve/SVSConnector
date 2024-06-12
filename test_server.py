import numpy as np
import pysvs
from quart import Quart, ResponseReturnValue, jsonify, request

app = Quart(__name__)

@app.get("/control/ping")
async def ping() -> ResponseReturnValue :
    return { "ping" : "pong" }

@app.route("/control/array", methods=["POST"])
async def load_to_svs() :
    try:
        data = await request.get_json()
        numpy_array = np.array(data, np.float32)
        # Verify that the array is 2-dimensional
        pysvs.write_vecs(numpy_array, "test_vecs.fvecs")
        return jsonify({"message" : "Successfully converted to numpy array",
                        "data" : numpy_array.tolist() })
    except Exception as e:
        return jsonify({"error" : f"Error converting data: {str(e)}"}), 400


def main():
    print("starting test")

    test_data_dir = "./example_data_vamana"
    pysvs.generate_test_dataset(
        10000,                      # Create 10000 vectors in the dataset.
        1000,                       # Generate 1000 query vectors.
        128,                        # Set the vector dimensionality to 128.
        test_data_dir,              # The directory where results will be generated.
        data_seed = 1234,           # Random number seed for reproducibility.
        query_seed = 5678,          # Random number seed for reproducibility.
        num_threads = 4,            # Number of threads to use.
        distance = pysvs.DistanceType.L2,   # The distance type to use.
    )

    parameters = pysvs.VamanaBuildParameters(
        graph_max_degree = 64,
        window_size = 128,
    )

    index = pysvs.Vamana.build(
        parameters,
        pysvs.VectorDataLoader(
            os.path.join(test_data_dir, "data.fvecs"), pysvs.DataType.float32
        ),
        pysvs.DistanceType.L2,
        num_threads = 4,
    )

    queries = pysvs.read_vecs(os.path.join(test_data_dir, "queries.fvecs"))
    groundtruth = pysvs.read_vecs(os.path.join(test_data_dir, "groundtruth.ivecs"))

    index.search_window_size = 30
    I, D = index.search(queries, 10)

    recall = pysvs.k_recall_at(groundtruth, I, 10, 10)
    print(f"Recall = {recall}")

    for window_size in range(10, 50, 10):
        index.search_window_size = window_size
        I, D = index.search(queries, 10)
        recall = pysvs.k_recall_at(groundtruth, I, 10, 10)
        print(f"Window size = {window_size}, Recall = {recall}")

    print("done test")

