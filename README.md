# Neo4j Demo Application
Very simple demo of how to use Neo4j with .NET.

## How to setup:

- **Install Neo4j:**
    - Download and install Neo4j from the [official website](https://neo4j.com/download/).
    - Alternatively, you can run Neo4j using Docker:
        ```shell
        docker run -d --name neo4j -p7474:7474 -p7687:7687 -e NEO4J_AUTH=neo4j/test neo4j
        ```

- **Add Neo4j.Driver NuGet package:**
    ```shell
    dotnet add package Neo4j.Driver
    ```



## How to run:
- Run docker compose up cmd:
    ```shell
    docker compose up --build
    ```
- Call endpoints:
    ```shell
    curl http://localhost:5000/api/person -H "Content-Type: application/json" -d '{"name":"Bob Jones","age":30}'
    ```
    ```shell
    curl http://localhost:5000/api/person
    ```
- Go to database in browser and see the data:
    http://localhost:7474

- While you're there have fun with the tutorials - they're pretty good.
Also check out this repo: https://github.com/neo4j-examples/movies-dotnetcore-bolt
