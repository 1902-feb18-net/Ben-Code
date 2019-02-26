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
        - For table 1, Phone depends on Supplier (and the other way around for that matter)
        - If there is one supplier per product, then we can say that if we know the Product, we know the supplier, or Supplier depends on Product
        - Color also depends on Product
- **Candidate Key**
    - For particular tables
    - The minimal set of columns that every other column depends on
        - Cannot remove anything more from the set without breaking the table
    - Product is our only candidate key from table 1
    - The values of any candidate key can uniquely identify that row
- **Primary Key** 
    - One of the candidate keys that we choose to actually identify the row
    - In table 1, the product would work and so would a product ID (assuming every product has a unique ID)
    - Any key with more than one column is a composite key
- **Foreign Key**
    - A column that has copies of another table's primary key to establish a relationship between the rows of the two tables

## Relational Databases
- Data organized into separate tables with rows and columns
```
Table 1
| Product   | Color       | Supplier  | Phone
|------------------------------------------------
| Widget    | Red         | Microsoft | 555-1234
| Thingy    | Black, red  | Amazon    | 555-4321
| Knicknack | Black, blue | Microsoft | 555-1234
```
- Tables are made up of data
