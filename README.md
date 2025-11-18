# EndpointBenchmark

Small playground to compare performance of different ASP.NET Core endpoint styles:

- Minimal APIs
- MVC Controllers
- FastEndpoints
- Carter
- ApiEndpoints

All use the same domain model (`Todo`, `TodoCreateReq`) and in-memory store (`InMemoryToDoDbContext`).

## Endpoints

All frameworks expose the same routes:

- `GET /hello`
- `GET /todos/{id:int}`
- `GET /todos`
- `GET /todos/large`
- `POST /todos`
- `GET /compute`

## NBomber scenarios

NBomber scenarios hit each route:

- `hello`
- `get_by_id`
- `get_list`
- `writes_light`
- `big_payload`
- `compute_only`

Reports are written to `./reports` in HTML/CSV/TXT.

To avoid overwriting reports between runs, use unique names, e.g.:

```csharp
.WithReportFolder("reports")
.WithReportFileName($"MinimalApi_{DateTime.UtcNow:yyyyMMdd_HHmmss}")


