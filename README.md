# CSharp NodeServices
Test NodeServices to run JavaScript and NPM Packages within C#

# Setup
* `npm install` to install `url-to-image` NPM Package

# Use
* Run project and visit:
  * https://localhost:44355/ -> Runs local add.js
  * https://localhost:44355/screenshot -> Runs local screenshot.js which uses `url-to-image` NPM package

# Known Problems
* Trying to run this project when it's already running will result in `HTTP Error 502.3 - Bad Gateway`. To fix this:
  * Clean solution and run again

  OR
  
  * Toggle between running with Debugger <kbd>F5</kbd> and without Debugger <kbd>CTRL</kbd>+<kbd>F5</kbd>.