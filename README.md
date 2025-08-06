# Fee Calculation Engine – Backend Challenge
## transaction fee calculator
__________________

## - Technologies
- ASP.NET Core Web API (.NET 8)
- In-Memory Data Storage for History
- Swagger for API testing
- Parallel Processing for Batch Efficiency

##  How to Run the Project (Setup < 5 mins)

1. Clone the repo:
```sh
git clone https://github.com/IvanaJ123/FeeCalculationEngine
cd FeeCalculationEngine
```


2. Run the API:
```sh 
dotnet run
```
3. Open Swagger UI:
- Go to `[https://localhost:xxxx/swagger]` (your browser should open this automaticaly at dotnet run)
- Test endpoints:
  - `POST /api/fee/calculate` – Single transaction
  - `POST /api/fee/batch` – Batch (1000 transactions)
  - `GET /api/fee/history` – All calculated transactions

## Batch Test File
- A batch test file `batch1000.json` is located in:
/BatchTestData/batch1000.json
- Open it in a text editor
- Copy contents of the JSON and paste into the POST /api/fee/batch request body

##  System Design Notes
- Rules implemented using **Strategy Pattern** (`IRule` interface).
- Easy to add new rules via new classes.
- Batch processing uses **Parallel.ForEach** for efficiency.
- History is stored **in-memory** for simplicity and fast access.




##  Project Structure
- `Controllers/` → API endpoints
- `Services/` → Fee calculator, rules engine
- `Data/` → History storage (in-memory)
- `Models/` → Request, Result, History classes
- `BatchTestData/` → JSON file for testing batch

## Time limitations
- Possible adding a persistent database storage (SQL Server) using Entity Framework and SQL Server Management Studio to store transaction history
