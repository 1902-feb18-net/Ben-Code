# SQL

## General SQL
- SQL (Structured Query Language)
    - SQL Server (the software, another name for the language itself)
    - TSQL or Transact SQL (the language itself)
    - MySQL
    - OracleSQL
    - PostgreSQL
    - SQLite
- Database management system (DBMS)
- **Functional Dependency** (or just Dependency)
    - A relationship between one set of columns and another set of columns
    - For two sets of columns X and Y, we can say there's a functional dependency between X and Y (or X depends on Y) if for each possible set of Y values, there is exactly one possible set of X values
        - Y --> X
        - If two rows had the same Y, you'd know the values of X must be the same
        - X is a fact about Y

## Relational Databases
- Data organized into separate tables with rows and columns

Table 1
| Product   | Color      | Supplier | Phone
|----------------------------------------------
| Widget    | Red        | Microsoft| 555-1234
| Thingy    | Black, red | Amazon   | 555-4321
| Knicknack | Black, blue| Microsoft| 555-2341

- Tables are made up of data
