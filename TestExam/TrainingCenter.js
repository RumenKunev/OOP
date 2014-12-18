function processTrainingCenterCommands(commands) {

    'use strict';

    Object.prototype.inherits = function(parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    var trainingcenter = (function () {

    var TrainingCenterEngine = (function () {

        var _trainers;
        var _uniqueTrainerUsernames;
        var _trainings;

        function initialize() {
            _trainers = [];
            _uniqueTrainerUsernames = {};
            _trainings = [];
        }

        function executeCommand(command) {
            var cmdParts = command.split(' ');
            var cmdName = cmdParts[0];
            var cmdArgs = cmdParts.splice(1);
            switch (cmdName) {
                case 'create':
                    return executeCreateCommand(cmdArgs);
                case 'list':
                    return executeListCommand();
                case 'delete':
                    return executeDeleteCommand(cmdArgs);
                default:
                    throw new Error('Unknown command: ' + cmdName);
            }
        }

        function executeCreateCommand(cmdArgs) {
            var objectType = cmdArgs[0];
            var createArgs = cmdArgs.splice(1).join(' ');
            var objectData = JSON.parse(createArgs);
            var trainer;
            switch (objectType) {
                case 'Trainer':
                    trainer = new trainingcenter.Trainer(objectData.username, objectData.firstName,
                        objectData.lastName, objectData.email);
                    addTrainer(trainer);
                    break;
                case 'Course':
                    trainer = findTrainerByUsername(objectData.trainer);
                    var course = new trainingcenter.Course(objectData.name, objectData.description, trainer,
                        parseDate(objectData.startDate), objectData.duration);
                    addTraining(course);
                    break;
                case 'Seminar':
                    trainer = findTrainerByUsername(objectData.trainer);
                    var seminar = new trainingcenter.Seminar(objectData.name, objectData.description,
                        trainer, parseDate(objectData.date));
                    addTraining(seminar);
                    break;
                case 'RemoteCourse':
                    trainer = findTrainerByUsername(objectData.trainer);
                    var remoteCourse = new trainingcenter.RemoteCourse(objectData.name, objectData.description,
                        trainer, parseDate(objectData.startDate), objectData.duration, objectData.location);
                    addTraining(remoteCourse);
                    break;
                default:
                    throw new Error('Unknown object to create: ' + objectType);
            }
            return objectType + ' created.';
        }

        function findTrainerByUsername(username) {
            if (! username) {
                return undefined;
            }
            for (var i = 0; i < _trainers.length; i++) {
                if (_trainers[i].getUsername() == username) {
                    return _trainers[i];
                }
            }
            throw new Error("Trainer not found: " + username);
        }

        function addTrainer(trainer) {
            if (_uniqueTrainerUsernames[trainer.getUsername()]) {
                throw new Error('Duplicated trainer: ' + trainer.getUsername());
            }
            _uniqueTrainerUsernames[trainer.getUsername()] = true;
            _trainers.push(trainer);
        }

        function deleteTrainer(trainer) {
            if (!_uniqueTrainerUsernames[trainer.getUsername()]) {
                throw new Error(trainer.getUsername() + 'does not exist!');
            }

            var indexOfTrainer = _trainers.indexOf(trainer);
            _trainers.splice(indexOfTrainer, 1);
        }

        function addTraining(training) {
            _trainings.push(training);
        }

        function executeListCommand() {
            var result = '', i;
            if (_trainers.length > 0) {
                result += 'Trainers:\n' + ' * ' + _trainers.join('\n * ') + '\n';
            } else {
                result += 'No trainers\n';
            }

            if (_trainings.length > 0) {
                result += 'Trainings:\n' + ' * ' + _trainings.join('\n * ') + '\n';
            } else {
                result += 'No trainings\n';
            }

            return result.trim();
        }

        function executeDeleteCommand(cmdArgs) {
            var objectType = cmdArgs[0];
            var deleteArgs = cmdArgs.splice(1).join(' ');
            switch (objectType) {
                case 'Trainer':
                    deleteTrainer(objectType.getUsername());
                    break;
                default:
                    throw new Error('Unknown object to delete: ' + objectType);
            }
            return objectType + ' deleted.';
        }

        var trainingCenterEngine = {
            initialize: initialize,
            executeCommand: executeCommand
        };
        return trainingCenterEngine;
    }());


    var Trainer = (function() {
        function Trainer(username, firstName, lastName, email){
            this.setUsername(username);
            this.setFirstName(firstName);
            this.setLastName(lastName);
            this.setEmail(email);

        }

        Trainer.prototype.getUsername = function() {
            return this._username;
        };

        Trainer.prototype.setUsername = function(username) {
            if(!username){
                throw new Error('Username could not be empty!');
            }
            this._username = username;
        };

        Trainer.prototype.getFirstName = function() {
            return this._firstName;
        };

        Trainer.prototype.setFirstName = function(firstName) {
            if(firstName && firstName.length <= 0){
                throw new Error('FirstName could not be empty!')
            }
            this._firstName = firstName;
        };

        Trainer.prototype.getLastName = function() {
            return this._lastName;
        };

        Trainer.prototype.setLastName = function(lastName) {
            if(!lastName){
                throw new Error('Username could not be empty!');
            }

            this._lastName = lastName;
        };

        Trainer.prototype.getEmail = function() {
            return this._email;
        };

        Trainer.prototype.setEmail = function(email) {
            if(email && (email.indexOf('@') == -1)){
                throw new Error('Username could not be empty!');
            }
            this._email = email;
        };

        Trainer.prototype.toString = function(){
            var result = '',
                firstName,
                email;

            firstName = this.getFirstName() ? 'first-name=' + this.getFirstName() + ';' : '';
            email = this.getEmail() ? ';email=' + this.getEmail() : '';

            result += 'Trainer[username=' + this.getUsername() + ';' +
                firstName +
                'last-name=' + this.getLastName() +
                email + ']';

            return result;
        };

        return Trainer;
    }());


    var Training = (function () {
        function Training (name, description, trainer, startDate, duration){
            if (this.constructor === Training) {
                throw new Error("Can't instantiate abstract class!");
            }

            this.setName(name);
            this.setDescription(description);
            this.setTrainer(trainer);
            this.setStartDate(startDate);
            this.setDuration(duration);
        }

        Training.prototype.getName = function(){
            return this._name;
        };

        Training.prototype.setName = function(name){
            this._name = name;
        };

        Training.prototype.getDescription = function(){
            return this._description;
        };

        Training.prototype.setDescription = function(description){
            this._description = description;
        };

        Training.prototype.getTrainer = function(){
            return this._trainer;
        };

        Training.prototype.setTrainer = function(trainer){
            this._trainer = trainer;
        };

        Training.prototype.getStartDate = function(){
            return this._startDate;
        };

        Training.prototype.setStartDate = function(startDate){
            this._startDate = startDate;
        };

        Training.prototype.getDuration = function(){
            return this._duration;
        };

        Training.prototype.setDuration = function(duration){
            if(duration){
                if(parseInt(duration) < 1 && parseInt(duration) > 99){
                    throw new Error('Duration should be in the range [1...99]');
                }
            }
            this._duration = duration;
        };

        Training.prototype.toString = function(){
            var result,
                description,
                trainer,

                result = '';
            description = this.getDescription() ? ';description=' + this.getDescription() : '';
            trainer = this.getTrainer() ? ';trainer=' +
                Trainer.prototype.toString.call(this.getTrainer()) : '';


            result += '[name=' + this.getName() +
                description + trainer;

            return result;
        };


        return Training;
    }());


    var Course = (function () {
        function Course(name, description, trainer, startDate, duration){
            if(!(this instanceof Course)) {
                return new Course(name, description, trainer, startDate, duration);
            }

            Training.call(this, name, description, trainer, startDate, duration);
        }

        Course.inherits(Training);

        Course.prototype.toString = function (){
            var result = '',
                duration;

            duration = this.getDuration() ? ';duration=' + this.getDuration() : '';

            result += 'Course' + Training.prototype.toString.call(this) +
                ';start-date=' + formatDate(this.getStartDate()) + duration + ']';

            return result;
        };

        return Course;
    }());


    var Seminar = (function () {
        function Seminar(name, description, trainer, startDate, duration){
            if(!(this instanceof Seminar)) {
                return new Seminar(name, description, trainer, startDate, duration);
            }

            Training.call(this, name, description, trainer, startDate, duration);
        }

        Seminar.inherits(Training);

        Seminar.prototype.toString = function (){
            var result = '',
                duration;

            duration = this.getDuration() ? ';duration=' + this.getDuration() : '';

            result += 'Seminar' + Training.prototype.toString.call(this) +
                ';date=' + formatDate(this.getStartDate()) + duration + ']';

            return result;
        };

        return Seminar;
    }());


    var RemoteCourse = (function () {
        function RemoteCourse(name, description, trainer, startDate, duration, location) {
            if(!(this instanceof RemoteCourse)) {
                return new RemoteCourse(name, description, trainer, startDate, duration, location);
            }

            Course.call(this, name, description, trainer, startDate, duration);

            this.setLocation(location);
        }

        RemoteCourse.inherits(Course);

        RemoteCourse.prototype.getLocation = function() {
            return this._location;
        };

        RemoteCourse.prototype.setLocation = function(location) {
            if(!location){
                throw new Error('Location could not be empty!')
            }
            this._location = location;
        };

        RemoteCourse.prototype.toString = function (){
            var result = '',
                duration;

            duration = this.getDuration() ? ';duration=' + this.getDuration() : '';

            result += 'RemoteCourse' + Training.prototype.toString.call(this) +
                ';start-date=' + formatDate(this.getStartDate()) + duration +
                ';location=' + this.getLocation() + ']';

            return result;
        };

        return RemoteCourse;
    }());


    var trainingcenter = {
        Trainer: Trainer,
        Course: Course,
        Seminar: Seminar,
        RemoteCourse: RemoteCourse,
        engine: {
            TrainingCenterEngine: TrainingCenterEngine
        }
    };

    return trainingcenter;
})();


var parseDate = function (dateStr) {
    if (!dateStr) {
        return undefined;
    }
    var date = new Date(Date.parse(dateStr.replace(/-/g, ' ')));
    var dateFormatted = formatDate(date);
    if (dateStr != dateFormatted) {
        throw new Error("Invalid date: " + dateStr);
    }
    return date;
}


var formatDate = function (date) {
    var day = date.getDate();
    var monthName = date.toString().split(' ')[1];
    var year = date.getFullYear();
    return day + '-' + monthName + '-' + year;
};


// Process the input commands and return the results
var results = '';
trainingcenter.engine.TrainingCenterEngine.initialize();
commands.forEach(function (cmd) {
    if (cmd != '') {
        try {
            var cmdResult = trainingcenter.engine.TrainingCenterEngine.executeCommand(cmd);
            results += cmdResult + '\n';
        } catch (err) {
            //console.log(err.stack);
            results += 'Invalid command.\n';
        }
    }
});
return results.trim();
}


// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

(function () {
    var arr = [];
    if (typeof (require) == 'function') {
        // We are in node.js --> read the console input and process it
        require('readline').createInterface({
            input: process.stdin,
            output: process.stdout
        }).on('line', function (line) {
            arr.push(line);
        }).on('close', function () {
            console.log(processTrainingCenterCommands(arr));
        });
    }
})();
