# Unit Conversion API

## Overview

This project is an ASP.NET Core 8 Web API that converts values between different units of measurement.

The API currently supports conversions for:

* Length
* Weight/Mass
* Temperature

The conversion factors are hardcoded as per the assignment requirements.

---

## Technologies Used

* ASP.NET Core 8 Web API
* Swagger / OpenAPI
* Dependency Injection
* Custom Exception Middleware

---

## Supported Conversions

### Length

* Meter ↔ Foot
* Kilometer ↔ Mile
* Centimeter ↔ Inch

### Weight

* Kilogram ↔ Pound
* Gram ↔ Ounce

### Temperature

* Celsius ↔ Fahrenheit
* Celsius ↔ Kelvin
* Fahrenheit ↔ Kelvin

---

## Running the Project

### Prerequisites

* .NET 8 SDK installed

### Steps

1. Clone the repository.

2. Navigate to the project directory.

3. Restore packages:

```bash
dotnet restore
```

4. Run the application:

```bash
dotnet run
```

5. Open Swagger in the browser:

```
https://localhost:<port>/swagger
```

---

## Sample Request

POST `/api/conversions`

Request Body:

```json
{
    "value": 10,
    "fromUnit": "Meter",
    "toUnit": "Foot"
}
```

Sample Response:

```json
{
    "originalValue": 10,
    "fromUnit": "Meter",
    "toUnit": "Foot",
    "convertedValue": 32.8084
}
```

---

## Design Decisions

* A single Web API project was used to keep the solution simple and maintainable.
* Conversion factors are hardcoded because a database was not required.
* Dictionaries were used for units with fixed conversion factors.
* Temperature conversions use formulas instead of fixed factors.
* Custom exception middleware provides consistent error responses.

---
