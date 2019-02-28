## SQL STUFF

- Multiplicity!
    - 1 to 1    -> 1 table, or 2 tables, FK UNIQUE
    - 1 to N    -> 2 tables - FK NOT NULL
    - 0/1 to N  -> 2 tables FK NULL
    - N to N    -> 3 tables, the middle one "junction table", "join table" with 2 FK

- **transaction**
    - ACID (defines a good transaction)
        A. *atomic* - All operations succeed 100% or do nothing at all
        C. *consistent* - Operations should not be allowed to violate constraints
        I. *isolated* - Even if multiple transactions run concurrently, it should be as if each was running alone (they shouldn't be allowed to interfere with each other)
        D. *durable* - Transactions are considered incomplete until written to persistent storage

- Issues:
    - Dirty read: See other transactions' unfinished work
        - Isolation level that fixes issue: read_uncommited (default)
    - Nonrepeatable read: read row twice, another finished transaction changed it in between
        - Fix: repeatable.read
    - Phantom read: other transactions can insert rows that meet conditions I'm filtering on
        - Fix: Serializable (invokes range lock)

- Multistatement transactions
    - BEGIN TRANSACTION
        - UPDATE
        - UPDATE
            Include an IF (...) ROLLBACK TRANSACTION (could put in a catch block)
        - SELECT
        - DELETE
    - COMMIT TRANSACTION