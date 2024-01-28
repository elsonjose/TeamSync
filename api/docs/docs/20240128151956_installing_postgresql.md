## Installing Postgresql
- [Instructions](https://ubuntu.com/server/docs/databases-postgresql)
- Create custom user with 
    ```
    $ CREATE USER ej with password '<Password Here>';
    ```
- To interact from Terminal
    ```
    $ psql -h localhost -U ej -d postgres
    ```
- Installed PgAdmin4 for UI