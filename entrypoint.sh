#!/bin/bash
echo "Waiting for SQL Server to start..."

./opt/mssql/bin/sqlservr &

until /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" -C -Q "SELECT 1"
do
  echo "Esperando..."
  sleep 10
done

echo "Creating Database script..."
/opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" -C -Q "CREATE DATABASE $NEW_DATABASE"

until /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" -d $NEW_DATABASE -C -Q "SELECT 1"
do
  echo "Esperando db $NEW_DATABASE..."
  sleep 10
done

echo "Running script..."
/opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" -C -d $NEW_DATABASE -i /usr/src/app/script.sql

tail -f /dev/null