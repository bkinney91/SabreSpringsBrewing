// vue.config.js
module.exports = {
	// options...
	configureWebpack: {
		devtool: 'source-map'
	  },
	devServer: {
		host: "localhost",
		open: "Google Chrome",
		port: 8080
	}
};
