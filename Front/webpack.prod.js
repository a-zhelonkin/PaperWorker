const path = require("path");
const merge = require("webpack-merge");
const config = require("./webpack.config.js");
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const OptimizeCSSAssetsPlugin = require("optimize-css-assets-webpack-plugin");

const outputDirectory = path.resolve(__dirname, "Scripts/dist");
const nodeModulesDirectory = path.resolve(__dirname, "node_modules");

module.exports = merge(config, {
    mode: "production",
    module: {
        rules: [
            {
                test: /\.css$/,
                use: [MiniCssExtractPlugin.loader, "css-loader"]
            }
        ]
    },
    plugins: [
        new UglifyJsPlugin({
            include: outputDirectory,
            exclude: [
                nodeModulesDirectory
            ],
            cache: true,
            parallel: true,
            sourceMap: false
        }),
        new OptimizeCSSAssetsPlugin({}),
        new MiniCssExtractPlugin({
            filename: "[name].css"
        })
    ],
});