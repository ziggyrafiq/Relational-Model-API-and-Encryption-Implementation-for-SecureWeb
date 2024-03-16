/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 01 - Book Api
*  Date     :  	25/09/2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*
************************************************************************************************************/

const {
    src,
    dest,
    parallel,
    series,
    watch
} = require('gulp');


// Load plugins
const uglify = require('gulp-uglify');
const rename = require('gulp-rename');
const sass = require('gulp-sass');
const autoprefixer = require('gulp-autoprefixer');
const cssnano = require('gulp-cssnano');
const concat = require('gulp-concat');
const clean = require('gulp-clean');
const imagemin = require('gulp-imagemin');
const changed = require('gulp-changed');
const browsersync = require('browser-sync').create();
const order = require("gulp-order");
const merge = require('merge2'); 
const sourcemaps = require('gulp-sourcemaps');



// Clean assets

function clear() {
    return src('wwwroot/Styles/CSS/*', {
        read: false
    })
        .pipe(clean());
}



// JS function 
function js() {
    const source = 'wwwroot/Scripts/Js/**/*.js';

    return src(source)
        .pipe(order([
            "Js/alert-hello.js"
        ]))
        .pipe(changed(source))
        .pipe(concat('ZR-App-Scripts.js'))
        .pipe(uglify())
        .pipe(dest('wwwroot/Scripts/'))
        .pipe(browsersync.stream());
 
}

// CSS function 
function css() {
    const source = 'wwwroot/Styles/SASS/**/*.scss';

    return src(source)
        .pipe(changed(source))
        .pipe(sass())
        .pipe(autoprefixer({
            overrideBrowserslist: ['last 2 versions'],
            cascade: false
        }))
        .pipe(dest('wwwroot/Styles/CSS/'))
        .pipe(browsersync.stream());
}

// Optimize images

function img() {
    return src('wwwroot/Images/**/*')
        .pipe(imagemin())
        .pipe(dest('wwwroot/Images/'));
}

// Watch files

function watchFiles() {
watch('wwwroot/Styles/SASS/**/*.scss', css);
    watch('wwwroot/Scripts/Js/**/*.js', js);
    watch('wwwroot/Images/**/*', img);
}

// BrowserSync

function browserSync() {
    browsersync.init({
        server: {
            baseDir: './',
            files: 'MockUp.html'
            

        },
        port: 3000
    });
}

// Tasks to define the execution of the functions simultaneously or in series

exports.watch = parallel(watchFiles, browserSync);

exports.build = series(clear, parallel(js, css, img));



