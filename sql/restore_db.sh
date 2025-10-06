#!/bin/bash

# Esperar a que SQL Server esté listo
echo "Esperando a que SQL Server arranque..."
sleep 30s

# Verificar que sqlcmd funciona
echo "Verificando conexión con sqlcmd..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "Wgutierrez07" -Q "SELECT @@VERSION as Version;" -b

if [ $? -ne 0 ]; then
    echo "ERROR: No se pudo conectar a SQL Server"
    exit 1
fi

# Restaurar la base de datos desde el backup
echo "Restaurando base de datos..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "Wgutierrez07" -Q "
RESTORE DATABASE [MicroPortal] 
FROM DISK = N'/var/opt/mssql/backups/MicroPortal.bak' 
WITH 
    REPLACE,
    STATS=5,
    MOVE 'MicroPortal' TO '/var/opt/mssql/data/MicroPortal.mdf',
    MOVE 'MicroPortal_log' TO '/var/opt/mssql/data/MicroPortal_log.ldf';"

if [ $? -eq 0 ]; then
    echo "✅ Base de datos restaurada exitosamente"
else
    echo "❌ Error en la restauración de la base de datos"
    exit 1
fi

echo "✅ Configuración completada exitosamente"
echo "🔗 Puedes conectarte con:"
echo "   Server=sqlserver,1433;Database=MicroPortal;User Id=sa;Password=Wgutierrez07"