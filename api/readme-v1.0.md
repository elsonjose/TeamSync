# TeamSync Documentation - v1.0

### Project Information

- ### Organisation Level

  1.  #### Sign up 
        Register the organisation using organisation name, email, password. A new user with admin privileges will be created acting as the root user who has all permissions for the organistion. The admin user can reuse the user login functionality. This is the only functionality available specific for the admin user.

- ### User Level

  - #### Admin
    The admin email needs to be verified before the following functionalities can be accessed.
    1. ##### Sign In
       The admin can sign in using email and password.
    2. ##### Add User
       Add new user to the organisation
    3. ##### Manage User
       Deactive or delete the user.
    4. ##### Verify user regularisation
       Approve or reject corrections made by the user.
  - #### User
    1. ##### Sign In
       The user can sign in using email and password.
    2. ##### Clock in
       User can clock in. This creates a new entry in time-logs. Also updates users table with additional info.
    3. ##### Clock out
       User can clock out. This makes the same changes.
    4. ##### Corrections
       User can regularize their attendance.
<hr>

### Learnings

The things learnt during development have been documented [here](docs/readme.md).
