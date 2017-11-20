var path = require('path');
var webpack = require('webpack');

module.exports = {
    entry: './Scripts/react-composer-app/App.jsx',
    output: { path: path.resolve(__dirname, "Scripts/react-composer-app/compiled"), filename: 'bundle.js' },
    module: {
        loaders: [
          {
              test: /.jsx?$/,
              loader: 'babel-loader',
              exclude: /node_modules/,
              query: {
                  presets: ['es2015', 'react']
              }
          }
        ]
    },
};