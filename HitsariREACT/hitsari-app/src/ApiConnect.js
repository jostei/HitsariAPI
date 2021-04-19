import React from 'react';

class ApiConnect extends React.Component{
    
    // Alustetaan tila
    constructor(props) {
        super(props);
        this.state = {entryt: null};

        console.log("ApiConnect.constructor");
    }
    
    // aloitetaan suoritus 
    componentDidMount(){
        console.log("ApiConnect.componentDidMount");

        fetch(this.props.url)
            .then(response => response.json())
            .then(json => {
                console.log("Ladattu " + json.length + " riviä");

                let tulokset = [];
                for (let indeksi = 0; indeksi < json.length; indeksi++) {
                    const userId = json[indeksi].WorkerId;
                    tulokset.push(json[indeksi])
                }
                console.log("Löydetty: "+ tulokset.length + " tulosta");

                // Päivitetään tila
                console.log("Päivitetään tila")
                this.setState( {entryt : tulokset });
                console.log("Tila päivitetty");
            });
    }

    // Suoritetaan alussa kerran, ja uudestaan aina kun tila päivitetään
    render(){
        console.log("ApiConnect.render");

        console.log("staten arvo: "+this.state.entryt)
        const otsikot = [];
        if(this.state.entryt){

            const entryt = this.state.entryt;
            console.log("this.state muuta kuin null, pituus: "+this.state.entryt.length)
            console.log("staten ekan title "+this.state.entryt[0].title)

            for (let indeksi = 0; indeksi < this.state.entryt.length; indeksi++) {
                const otsikko = entryt[indeksi].WorkerId;
                otsikot.push(<p key={indeksi}>{otsikko}</p>)

            }
        }

        return <>
            <div>
                <h1>Löydetyt hitsarit</h1>
                {otsikot}
            </div>
            </>
    }
}

export default ApiConnect;