var gulp = require("gulp");
var debug = require("gulp-debug");
var foreach = require("gulp-foreach");
var watch = require("gulp-watch");
var newer = require("gulp-newer");
var path = require("path");
var config = require("./gulp-config.js")();

module.exports.config = config;

/*****************************
 Watchers
*****************************/
gulp.task("Auto-Publish-Assets", function () {
  var cssRoot = "./assets/css";
  var jsRoot = "./assets/js";
  var cshtmlRoot = "./Views";

  var destination = config.websiteRoot + "\\FeydraRoot\\" + config.FeydraUser + "\\";

  gulp.src(cssRoot).pipe(
    foreach(function (stream, rootFolder) {
      gulp.watch([cssRoot + "/**/*.css", jsRoot + "/**/*.js", cshtmlRoot + "/**/*.cshtml"], function (event) {
        if (event.type === "changed") {
          console.log("publish file " + event.path);
          gulp.src(event.path, { base: './' }).pipe(gulp.dest(destination));
        }
        console.log("published " + event.path);
      });
      return stream;
    })
  );
});
