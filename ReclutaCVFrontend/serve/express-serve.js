// Este archivo cumple el propósito de servir la aplicación web utilizando Express.js
const express = require("express");
const path = require("path");

const app = express();

// Se sirven los archivos estáticos generados por el empaquetador
app.use(express.static(path.join(__dirname)));

// Con esto permitimos que la aplicación sea la que maneje la lógica para servir las rutas
app.get("*", (req,res) =>{
    res.sendFile(path.join(__dirname, "index.html"));
});

const port = process.env.PORT || 5000;
app.listen(port);

console.log("App is listening on port " + port);