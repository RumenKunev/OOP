Object.prototype.inherits = function(parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

var Shape = (function() {

    function validate() {
        if(this._pointX < 0 || this._pointY < 0) {
            throw 'Invalid number!';
        }
    }

    function Shape(pointX, pointY, color) {

        if (this.constructor === Shape) {
            throw new Error("Can't instantiate abstract class!");
        }

        this._pointX = pointX;
        this._pointY = pointY;
        this._color = color;

        validate.apply(this);

    }

    Shape.prototype.toString = function() {
        var result = '';
        result += 'X: ' + this._pointX + ', Y: ' + this._pointY + ', Color: ' + this._color;
        return result;
    };

    Shape.prototype.draw = function() {
        var myCanvas = document.getElementById("myCanvas");
        var context = myCanvas.getContext("2d");
        context.fillStyle = this._color;
        return context;
    };

    return Shape;
}());

var Circle = (function() {

    function Circle(pointX, pointY, color, radius) {
        if(!(this instanceof arguments.callee)) {
            return new arguments.callee(pointX, pointY, color, radius)
        }

        Shape.call(this, pointX, pointY, color);
        this.setRadius(radius);
    }

    Circle.inherits(Shape);

    Circle.prototype.getRadius = function() {
            return this._radius;
    };

    Circle.prototype.setRadius = function(radius) {
        this._radius = radius;
    };

    Circle.prototype.toString = function (){
        return Shape.prototype.toString.call(this) + ', Radius: ' + this.getRadius();
    };

    Circle.prototype.draw = function() {
        var context = Shape.prototype.draw(this);
        context.arc(this._pointX, this._pointY, this._radius, 0, 2*Math.PI);
        context.stroke();
    };

    return Circle;
}());

var Rectangle = (function() {
    function Rectangle(pointX, pointY, color, width, height) {
        if(!(this instanceof arguments.callee)){
            return new arguments.callee(pointX, pointY, color, width, height);
        }

        Shape.call(this, pointX, pointY, color);
        this.setWidth(width);
        this.setHeight(height);
    }

    Rectangle.inherits(Shape);

    Rectangle.prototype.getWidth = function() {
        return this._width;
    };

    Rectangle.prototype.setWidth = function(width) {
        this._width = width;
    };

    Rectangle.prototype.getHeight = function() {
        return this._height;
    };

    Rectangle.prototype.setHeight = function(height) {
        this._height = height;
    };

    Rectangle.prototype.toString = function() {
        return Shape.prototype.toString.call(this) +
            ', Width: ' + this.getWidth() +
            ', Height: ' + this.getHeight();
    };

    Rectangle.prototype.draw = function() {
        var context = Shape.prototype.draw(this);
        context.fillRect(this._pointX, this._pointY, this._width, this._height);
    };

    return Rectangle;
}());

var Triangle = (function () {
    function Triangle (pointX, pointY, color, x2, y2, x3, y3){
        if(!(this instanceof arguments.callee)) {
            return new arguments.callee(pointX, pointY, color, x2, y2, x3, y3);
        }

        Shape.call(this, pointX, pointY, color);
        this.setX2(x2);
        this.setY2(y2);
        this.setX3(x3);
        this.setY3(y3);
    }

    Triangle.inherits(Shape);

    Triangle.prototype.getX2 = function() {
        return this._x2;
    };

    Triangle.prototype.setX2 = function(x2) {
        this._x2 = x2;
    };

    Triangle.prototype.getY2 = function() {
        return this._y2;
    };

    Triangle.prototype.setY2 = function(y2) {
        this._y2 = y2;
    };

    Triangle.prototype.getX3 = function() {
        return this._x3;
    };

    Triangle.prototype.setX3 = function(x3) {
        this._x3 = x3;
    };

    Triangle.prototype.getY3 = function() {
        return this._y3;
    };

    Triangle.prototype.setY3 = function(y3) {
        this._y3 = y3;
    };

    Triangle.prototype.toString = function() {
        return Shape.prototype.toString.call(this) +
            ', X2: ' + this.getX2() +
            ', Y2: ' + this.getY2() +
            ', X3: ' + this.getX3() +
            ', Y3: ' + this.getY3();
    };

    Triangle.prototype.draw = function() {
        var context = Shape.prototype.draw(this);
        context.beginPath();
        context.moveTo(this._pointX, this._pointY);
        context.lineTo(this._x2, this._y2);
        context.lineTo(this._x3, this._y3);
        context.fill();
    };

    return Triangle;
}());

var Segment = (function () {
    function Segment (pointX, pointY, color, x2, y2){
        if(!(this instanceof arguments.callee)){
            return new arguments.callee(pointX, pointY, color, x2, y2);
        }

        Shape.call(this, pointX, pointY, color);
        this.setX2(x2);
        this.setY2(y2);
    }

    Segment.inherits(Shape);

    Segment.prototype.getX2 = function() {
        return this._x2;
    };

    Segment.prototype.setX2 = function (x2) {
       this._x2 = x2;
    };

    Segment.prototype.getY2 = function() {
        return this._y2;
    };

    Segment.prototype.setY2 = function (y2) {
        this._y2 = y2;
    };

    Segment.prototype.toString = function(){
        return Shape.prototype.toString.call(this) +
            ', X2: ' + this.getX2() +
            ', Y2: ' + this.getY2();
    };


    return Segment;
}());

var Point = (function(){
    function Point(pointX, pointY, color){
        if(!(this instanceof arguments.callee)){
            return new arguments.callee(pointX, pointY, color);
        }

        Shape.call(this, pointX, pointY, color);
    }

     Point.inherits(Shape);

    Segment.prototype.toString = function(){
        return Shape.prototype.toString.call(this);
    };

    return Point;
}());


var circle = new Circle(40, 40, '#fff', 20);
console.log(circle.draw());
var rectangle = new Rectangle(70, 70, '#fff', 40, 30);
console.log(rectangle.draw());
var triangle = new Triangle(300, 200, '#fff', 400, 250, 150, 350);
console.log(triangle.draw());

