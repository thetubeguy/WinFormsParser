
# WinForms CSV Parser

Parsers a text file into a SQLite in-memory DB.

## Usage

On execution a single form opens.

Select the input file.

Select the delimiter to use.

Click **Parse**.

Select a pre-defined query and click **Run Query**


## Technical

A table is created in the SQLite DB with a column corresponding to each header in the input file.  
This table has an additional column for the default SQLite index **rowid**

Queries are run against this table using SQL statements where possible, and Regular Expressions where needed.
