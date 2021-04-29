import React from 'react';

class ApiWorkerit extends React.Component{
    
    // Alustetaan tila
    constructor(props) {
        super(props);
        this.state = {wokrerit: null};

        console.log("ApiConnect.constructor");
    }
    
    // aloitetaan suoritus 
    componentDidMount(){
        console.log("ApiConnect.componentDidMount");

        fetch("https://localhost:44317/api/Worker/tolist")
            .then(response => response.json())
            .then(tyomiehet => {
                console.log(tyomiehet);
                // Päivitetään tila
                console.log("Päivitetään workerit")
                this.setState( {workerit : tyomiehet });
                console.log("Tila päivitetty");
            });
    }

    // Suoritetaan alussa kerran, ja uudestaan aina kun tila päivitetään
    render(){
        console.log("ApiConnect.render");

        const taulukko = [];

        if (this.state.workerit) {
            const workerit = this.state.workerit;
            console.log("ApiConnect.render --> tila alustettu, workerit.length: " + workerit.length);

            for (let indeks = 0; indeks < workerit.length; indeks++) {
                const work = workerit[indeks];
                taulukko.push(<tr key={indeks}>
                    <td>{work.workerId}</td>
                    <td>{work.etunimi+work.sukunimi}</td>
                    <td>{work.toimipiste}</td>
                    <td>{work.lisäyspäivä}</td>
                    <td>{work.muokattu}</td>
                </tr>)
            }
        }

        return <>            
            <h1>Löydettyt työntekijät</h1>
            <table>
                <thead>
                    <tr>
                        <th>Worker Id</th>
                        <th>Nimi</th>
                        <th>Toimipiste</th>
                        <th>Lisäyspäivä</th>
                        <th>Muokattu</th>
                    </tr>
                </thead>
                <tbody>
                    {taulukko}
                </tbody>
            </table>
            </>
    }
}

export default ApiWorkerit;