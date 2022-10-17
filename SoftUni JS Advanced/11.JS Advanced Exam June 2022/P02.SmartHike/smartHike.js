class SmartHike{
    constructor(username){
        this.username = username;
        this.resources = 100;
        this.listOfHikes = [];
        this.goals = {};
    }

    addGoal = (peak, altitude) => {

        if(!this.goals[peak]){
            this.goals[peak] = Number(altitude);

            return `You have successfully added a new goal - ${peak}`;
        }

        return `${peak} has already been added to your goals`;
    }

    hike = (peak, time, difficultyLevel) => {
        if(!this.goals[peak]){
            throw new Error(`${peak} is not in your current goals`);
        }
        if(this.resources <= 0){
            throw new Error(`You don't have enough resources to start the hike`);
        }

        let difference = this.resources - (Number(time) * 10);
        if(difference < 0){
            return `You don't have enough resources to complete the hike`;
        }

        this.resources = difference;
        this.listOfHikes.push({peak, time, difficultyLevel});

        return `You hiked ${peak} peak for ${time} hours and you have ${this.resources}% resources left`;
    }

    rest = (time) => {
        let timeToNumber = Number(time);

        this.resources += timeToNumber * 10;

        if(this.resources >= 100){
            return `Your resources are fully recharged. Time for hiking!`;
        }

        return `You have rested for ${timeToNumber} hours and gained ${timeToNumber * 10}% resources`;
    }

    showRecord = (criteria) => {
        if(this.listOfHikes.length === 0){
            return `${username} has not done any hiking yet`;
        }

        let bestHike = {};
        switch (criteria) {
            case `hard`:
                bestHike = this.listOfHikes.filter(hike => {
                    return hike.difficultyLevel === `hard`
                }).sort((hikeA, hikeB) => {
                    return hikeA.time - hikeB.time || hikeA
                })[0];
                break;

            case `easy`:
                bestHike = this.listOfHikes.filter(hike => {
                    return hike.difficultyLevel === `easy`
                }).sort((hikeA, hikeB) => {
                    return hikeA.time - hikeB.time || hikeA
                })[0];
                break;

            case `all`:
                let result = `All hiking records:\n`;
                for(let hike of this.listOfHikes){
                    result += `${this.username} hiked ${hike.peak} for ${hike.time} hours\n`;
                }
                return result.trim();
        }

        if(!bestHike){
            return `${this.username} has not done any ${criteria} hiking yet`;
        }
    
        return `${this.username}'s best ${criteria} hike is ${bestHike.peak} peak, for ${bestHike.time} hours`;
    }
}

const user = new SmartHike('Vili');
console.log(user.addGoal('Musala', 2925));
// console.log(user.addGoal('Rui', 1706));
console.log(user.addGoal('Todorka', 2706));
console.log(user.hike('Musala', 4, 'hard'));
console.log(user.hike('Todorka', 4, 'hard'));

console.log(user.showRecord(`hard`))
