import pyodbc

def connect():
    connection_string = ("DRIVER={ODBC Driver 18 for SQL Server};"
    "Server=COMP7A2\\SQLEXPRESS;"
    "Database=TestIndex2;"
    "Trusted_Connection=yes;"
    "Encrypt=yes;"
    "TrustServerCertificate=yes")
    connection = pyodbc.connect(connection_string)
    return connection



def main():
    table_names = ["orders2", "Table_1"]
    conn = connect()
    add_data(conn, table_names[1])
    curr = select_data(conn,table_names[1])
    # print_data(curr)

def select_data(conn,name):
    cursor = conn.cursor()
    sql_command = f"SELECT TOP 10 * FROM dbo.{name}"
    cursor.execute(sql_command)
    return cursor

def add_data(conn,name):
    cursor = conn.cursor()
    sql_command = f"INSERT INTO dbo.{name}(id, name, balance, credit) VALUES(?, ?, ?, ?)"
    cursor.execute(sql_command, 3, 'tolik', 100.0, 50.0)
    cursor.commit()

def print_data(cursor):
    rows = cursor.fetchall()
    for row in rows:
        print(row)

main()