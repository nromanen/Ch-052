var path = require('path');
var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var CleanWebpackPlugin = require('clean-webpack-plugin');
console.log('@@@@@@@@@ USING DEVELOPMENT @@@@@@@@@@@@@@@');
module.exports = {
    devtool: 'source-map',
    performance: {
        hints: false
    },
    entry: {
        "polyfills": "./UI/src/polyfills.ts",
        "app": "./UI/src/main.ts"
    },
    output: {
        path: path.resolve(__dirname, "./" ),
        filename: 'angularBundle/[name].build.js'
    },
    resolve: {
        extensions: ['.ts', '.js', '.json', '.css', '.scss', '.html', '.cshtml'],
        modules: [path.resolve(__dirname, './node_modules')]
    },
    module: {
        rules: [{
            test: /\.ts$/,
            loaders: [{
                loader: 'awesome-typescript-loader',
                options: { configFileName: path.resolve(__dirname, './tsconfig.json') }
            }, 'angular2-template-loader']
        }, {
            test: /\.(png|jpg|gif|woff|woff2|ttf|svg|eot)$/,
            loader: 'file-loader?name=assets/[name].[ext]'
        }, {
            test: /favicon.ico$/,
            loader: 'file-loader?name=/[name].[ext]'
        }, {
            test: /\.css$/,
            loader: 'to-string-loader!style-loader!css-loader'
        }, {
            test: /\.scss$/,
            exclude: /node_modules/,
            loaders: ['style-loader', 'css-loader', 'sass-loader']
        }, {                                     
            test: /\.html$/,
            loader: 'raw-loader'
        }],
        exprContextCritical: false
    },
    plugins: [
        new webpack.optimize.CommonsChunkPlugin({         
            name: ['app', 'polyfills', /*'vendor'*/]
        }),
        new CleanWebpackPlugin(
            ['./AngularBundle', ]),
        new HtmlWebpackPlugin({
            template: "./Views/Home/loader",
			filename: "./Views/Home/Index.cshtml",
            inject: false,
        }),
         new webpack.ProvidePlugin({
             jQuery: 'jquery',
             $: 'jquery',
             jquery: 'jquery'  
         })
    ]
};