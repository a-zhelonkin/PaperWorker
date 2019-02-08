const path = require("path");
const merge = require("webpack-merge");
const config = require("./webpack.config.js");
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const OptimizeCSSAssetsPlugin = require("optimize-css-assets-webpack-plugin");

const outputDirectory = path.resolve(__dirname, "wwwroot");
const nodeModulesDirectory = path.resolve(__dirname, "node_modules");

module.exports = merge(config, {
    mode: "production",
    module: {
        rules: [
            {
                test: /\.scss$/,
                use: [MiniCssExtractPlugin.loader, "css-loader", "sass-loader"]
            },
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
            filename: "[name].css",
            chunkFilename: "[id].css"
        })
    ],
});