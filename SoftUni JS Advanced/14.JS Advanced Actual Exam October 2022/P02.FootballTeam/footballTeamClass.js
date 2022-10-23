class footballTeam{
    constructor(clubName, country){
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions = (footballPlayers) => {
        let invitedPlayersNames = [];

        footballPlayers.forEach(info => {
            let playerInfo = info.split(`/`);

            let name = playerInfo[0];
            let age = Number(playerInfo[1]);
            let playerValue = Number(playerInfo[2]);
            
            let searchedPlayer = this.invitedPlayers.find(player => player.name === name);

            if (!searchedPlayer) {
                this.invitedPlayers.push({
                    name,
                    age,
                    playerValue
                });
            } else {
                if (searchedPlayer.playerValue < playerValue && searchedPlayer.playerValue !== `Bought`) {
                    searchedPlayer.playerValue = playerValue;
                }
            }

            if(!invitedPlayersNames.includes(name)){
                invitedPlayersNames.push(name);
            }
        });

        return `You successfully invite ${invitedPlayersNames.join(`, `)}.`
    }

    signContract = (selectedPlayer) => {
        let splitted = selectedPlayer.split(`/`);

        let name = splitted[0];
        let playerOffer = Number(splitted[1]);

        let searchedPlayer = this.findPlayer(name);
        
        let difference = searchedPlayer.playerValue - playerOffer;

        if(difference > 0){
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${difference} million more are needed to sign the contract!`);
        }

        searchedPlayer.playerValue = `Bought`;

        return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`;
    }

    ageLimit = (name, age) => {
        let ageLimit = Number(age);

        let searchedPlayer = this.findPlayer(name);

        if(searchedPlayer.age < ageLimit){
            let ageDifference = ageLimit - searchedPlayer.age;

            if(ageDifference < 5){
                return `${name} will sign a contract for ${ageDifference} years with ${this.clubName} in ${this.country}!`;
            }
            return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
        }
        
        return `${name} is above age limit!`;
    }

    transferWindowResult = () => {
        let result = `Players list:\n`;

        let playerInfo = this.invitedPlayers.sort((playerA, playerB) => {
            playerA.name.localeCompare(playerB.name)
        }).map(player => {
            return `Player ${player.name}-${player.playerValue}`
        });

        result += `${playerInfo.join(`\n`)}`;

        return result.trim();
    }

    findPlayer = (playerName) => {
        let searchedPlayer = this.invitedPlayers.find(player => player.name === playerName);

        if(!searchedPlayer){
            throw new Error(`${playerName} is not invited to the selection list!`);
        }
        return searchedPlayer;
    }
}

let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.signContract("Kylian Mbappé/160"));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.transferWindowResult());