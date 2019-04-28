module.exports = function (callback, a, b) {
    let result = a + b;
    callback(/* error */ null, result);
};