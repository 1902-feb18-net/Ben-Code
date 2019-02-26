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
    - A column that has copies of a table's primary key to establish a relationship between the rows of the two tables
- **Non-atomic values**
    - A value that is not indivisible (or atomic)
    - Problem: Hard to read values, have to search through strings
        - Ex: searching for the "red" in table 1
- **Update Anomaly**
    - With redundant data, we might not update all copies
- **Deletion Anomaly**
    - If we delete some data we sometimes lose other data
    - Ex: in table 1, if you delete Thingybob then you also delete Amazon's phone number
- **Insertion Anomaly**
    - It becomes impossible to insert data without some associated data
    - Ex: in table 1, cannot insert an Amazon product without knowing their phone number
- **Normalization**
    - Process of restructuring how our data is set up
    - First Normal Form (1NF)
        - Theorists and developers have slightly different ideas
        1. No duplicate rows (enforce that with a primary key)
        2. No atomic values
            - For table 1, you could create extra columns for colors past the first
        3. No repeating groups of columns
            - So don't actually have multiple colors columns in table 1
            - Instead, you can add another row with the color entry being different
            - Make the composite primary key of Primary ID and color (or Product and Color)
            - Alternatively, alter ID so that it refers to color and product instead of just product (table 1b)
    - Second Normal Form (2NF)
    - Third Normal  Form (3NF)
        - "Full normalized" as for as most are concerned
    
## Relational Databases
- Data organized into separate tables with rows and columns

Table 1

| ID | Product   | Color       | Supplier  | Phone
|----------------------------------------------------
| 1  | Widget    | Red         | Microsoft | 555-1234
| 2  | Thingy    | Black, red  | Amazon    | 555-4321
| 3  | Knicknack | Black, blue | Microsoft | 555-1234

Table 1.b

| ID | Product   | Color | Supplier  | Phone
|----|-----------|-------|-----------|---------------
| 1  | Widget    | Red   | Microsoft | 555-1234
| 2  | Thingy    | Black | Amazon    | 555-4321
| 3  | Knicknack | Black | Microsoft | 555-1234
| 4  | Thingy    | red   | Amazon    | 555-4321
| 5  | Knicknack | blue  | Microsoft | 555-1234

- Tables are made up of data
