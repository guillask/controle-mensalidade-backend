```
1. Create project:
dotnet new webapi -n controle-mensalidade-backend
(replace generated content with the above files or add them)


2. Install EF tool (if needed):
dotnet tool install --global dotnet-ef


3. Add packages (if not in csproj):
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Swashbuckle.AspNetCore


4. Create migration and apply to DB:
dotnet ef migrations add InitialCreate
dotnet ef database update


5. Run:
dotnet run


Main Endpoints:
- GET /api/schools -> list schools
- GET /api/schools/{schoolId}/monthlyfees -> list monthly fees of a school
- GET /api/monthlyfees -> list all monthly fees
- GET /api/monthlyfees/{monthlyFeeId}/installments -> list installments of a monthly fee
- GET /api/installments/student/{studentId} -> list installments of a student
- PUT /api/installments/{installmentId}/pay -> mark installment as paid


Suggestions:
- Add validation, DTOs and AutoMapper to avoid exposing entities directly in production.
- Add authentication/authorization as needed.
- Add unit/integration tests.
```


--- End of document