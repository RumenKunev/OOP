var specialConsole = (function (){
    function writeLine() {
        var output;

        if (arguments.length === 1) {
            output = arguments[0];
        }

        var argumentsAsArray = Array.prototype.slice.call(arguments),
            i,
            placeHolder;

        for (i = 1; i < argumentsAsArray.length; i += 1) {
            placeHolder = '{' + (i - 1) + '}';
            output = argumentsAsArray[0].replace(placeHolder, argumentsAsArray[i]);
            argumentsAsArray[0] = output;
        }
        console.log(output);
    }
    return {
        writeLine: writeLine,
        writeError: writeLine,
        writeWarning: writeLine
    };
}());

//specialConsole.writeLine('Message: hello');
specialConsole.writeLine('Message: {0}', 'hello');
specialConsole.writeLine('Message: {0} {1}', 'hello', 'Rumen');
specialConsole.writeLine('Error: {0} {1} from {2}', 'hello', 'Rumen', 'Kaspichan');
