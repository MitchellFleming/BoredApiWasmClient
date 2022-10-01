#!/bin/bash
echo "Building BoredApiWasmClient Docker Image";
dotnet clean
rm -rf BoredApiWasmClient/bin
rm -rf BoredApiWasmClient/obj
docker build -t <yourdocker>/bored-api-client
docker run -p 8080:80 <yourdocker>/bored-api-client