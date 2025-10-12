# Etapa 1: construir el JAR
FROM maven:3.9.6-eclipse-temurin-17 AS build
WORKDIR /app

# Copiar archivos del proyecto
COPY pom.xml .
COPY src ./src

# Compilar el proyecto
RUN mvn clean package -DskipTests

# Etapa 2: imagen final
FROM eclipse-temurin:17-jdk
WORKDIR /app

# Copiar el JAR generado desde la etapa anterior
COPY --from=build /app/target/*.jar app.jar

# Exponer el puerto (ajústalo si tu app usa otro)
EXPOSE 8080

# Comando para ejecutar la app
ENTRYPOINT ["java", "-jar", "app.jar"]
