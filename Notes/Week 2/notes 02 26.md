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
    - Non-CK columns should depend on "the keys (1NF), the whole keys (2NF), and nothing but the keys (3NF)"
    - First Normal Form (1NF)
        - Theorists and developers have slightly different ideas
        1. No duplicate rows (enforce that with a primary key)
        2. Only atomic values
            - For table 1, you could create extra columns for colors past the first
        3. No repeating groups of columns
            - So don't actually have multiple colors columns in table 1
            - Instead, you can add another row with the color entry being different
            - Make the composite primary key of Primary ID and color (or Product and Color)
            - Alternatively, alter ID so that it refers to color and product instead of just product (table 1b)
        - Table 1b is in 1NF and is in a "N-to-1" relationship between color and product/ID
    - Second Normal Form (2NF)
        1. Is in 1NF
        2. No non-candidate key column may depend on PART of any composite candidate key (as opposed to the entire thing)
            - No partial dependency
            - Table 2 is not in 2NF because Region depends on state, as opposd to City and State together
            - Table 2.b and 2.c are in 2NF
        - Tables 1e and 1f are an example of 2NF
        - 
    - Third Normal Form (3NF)
        - "Full normalized" as for as most are concerned
        1. In 2NF
        2. No non-candidate key column can depend on any non-condidate key column
            - No transitive dependencies
        - Tables 2.b and 2.c are also in 3NF
        - However, table 1.b is not in 3NF form, nor is 1.c and 1.d
            - Supplier and phone rely on each other
        - Tables 1.e and 1.f are in 3NF
    - Pros: 
        - Less redundancy
        - Less errors
        - Easier to evolve data model
        - Easier to read and write with consistency; all the rules are not violated
    - Cons:
        - Can make some queries slower if there are too many tables interdependent on each other
    
## Relational Databases
- Data organized into separate tables with rows and columns

Table 1

| ID | Product   | Color       | Supplier  | Phone
|----|-----------|-------------|-----------|---------
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

Table 1c

| ID | Product   | Supplier  | Phone
|----|-----------|-----------|---------------
| 1  | Widget    | Microsoft | 555-1234
| 2  | Thingy    | Amazon    | 555-4321
| 3  | Knicknack | Microsoft | 555-1234

Table 1d

| Product ID | Color   
|------------|---------
| 1          | Red    
| 2          | Black    
| 3          | Black 
| 4          | Red    
| 5          | Blue 

Table 1.e

| ID | Product   | Supplier  |
|----|-----------|-----------|
| 1  | Widget    | Microsoft |
| 2  | Thingy    | Amazon    |
| 3  | Knicknack | Microsoft |
| 4  | Thingy    | Amazon    |
| 5  | Knicknack | Microsoft |

Table 1.f

| Supplier  | Phone    |
|-----------|----------|
| Microsoft | 555-1234 |
| Amazon    | 555-4321 |



Table 2

| CityID | City | State | Region | SalesTotal |
|--------|------|-------|--------|------------|
|        |      |       |        |            |
|        |      |       |        |            |

Candidate keys: CityID, City and State

Table 2.b

| CityID | City | State | SalesTotal |
|--------|------|-------|------------|
|        |      |       |            |
|        |      |       |            |

Table 2.c

| State | Region |
|-------|--------|
|       |        |
|       |        |

- Tables are made up of data
