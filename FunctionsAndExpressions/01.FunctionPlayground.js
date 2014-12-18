function printArguments(){
    var result = '';

    for(var arg in arguments) {
        result += arg + '->' + typeof arguments[arg] + '\n';
    }
    console.log(result);
}
printArguments(1,  4);
printArguments('test', false, 5.77);

console.log(new Array(11).join('*')) + '\n';

name = 'Rumen';

function scopeTest(age){
       console.log(this.name + ', ' + age);
}


scopeTest(22);
scopeTest.call({name: 'Goshko'}, 33);








