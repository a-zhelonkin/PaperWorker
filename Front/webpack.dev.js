const path = require("path");
const merge = require("webpack-merge");
const config = require("./webpack.config.js");

const nodeModulesDirectory = path.resolve(__dirname, "node_modules");

module.exports = merge(config, {
    mode: "development",
    module: {
        rules: [
            {
                test: /\.jsx?$/,
                enforce: "pre",
                exclude: nodeModulesDirectory,
                use: ["source-map-loader"]
            },
            {
                test: /\.css$/,
                use: ["style-loader", "css-loader"]
            }
        ]
    },
    devtool: "inline-source-map",
    devServer: {
        port: 3000,
        open: true,
        proxy: {
            "/api": "http://localhost:8080"
        }
    },
});