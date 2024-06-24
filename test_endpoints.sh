#!/bin/bash

echo "Testing GET /api/cars"
curl -X GET "http://localhost:5000/api/cars"

echo "Testing POST /api/cars"
curl -X POST "http://localhost:5000/api/cars" -H "Content-Type: application/json" -d '{"make":"Toyota", "model":"Corolla", "year":2020}'
