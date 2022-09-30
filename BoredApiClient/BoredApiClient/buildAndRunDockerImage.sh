#!/bin/bash
echo "Building BoredApiWasmClient Docker Image";
dotnet clean
rm -rf BoredApiClient/bin
rm -rf BoredApiClient/obj
docker build -t <yourdocker>/bored-api-client
docker run -p 8080:80 <yourdocker>/bored-api-client