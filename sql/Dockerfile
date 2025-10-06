FROM mcr.microsoft.com/mssql/server:2022-latest

# Variables de entorno requeridas por SQL Server
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Wgutierrez07

# Instalar sqlcmd y herramientas necesarias
USER root

# Actualizar e instalar dependencias (usando Ubuntu 22.04)
RUN apt-get update && \
    apt-get install -y curl gnupg && \
    # Descargar e instalar las herramientas de Microsoft para Ubuntu 22.04
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/ubuntu/22.04/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && \
    ACCEPT_EULA=Y apt-get install -y mssql-tools unixodbc-dev && \
    # Agregar sqlcmd al PATH
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc && \
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> /etc/profile.d/mssql-tools.sh && \
    # Limpiar cache
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

# Crear carpetas necesarias
RUN mkdir -p /var/opt/mssql/backups && \
    mkdir -p /var/opt/mssql/scripts

# Copiar backups y script
COPY ./backups/ /var/opt/mssql/backups/
COPY ./restore_db.sh /var/opt/mssql/scripts/

# Dar permisos de ejecución
RUN chmod 755 /var/opt/mssql/scripts/restore_db.sh

# Verificar que sqlcmd esté instalado
RUN /opt/mssql-tools/bin/sqlcmd -? | head -n 1

# Verificar que el archivo tiene permisos correctos
RUN ls -la /var/opt/mssql/scripts/restore_db.sh

# Volver al usuario mssql para seguridad
USER mssql

# Ejecutar el script en segundo plano y luego SQL Server
CMD /bin/bash -c "/var/opt/mssql/scripts/restore_db.sh & /opt/mssql/bin/sqlservr"