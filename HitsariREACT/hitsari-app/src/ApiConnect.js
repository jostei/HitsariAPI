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

        /*
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
        */

            // testaukseen "https://jsonplaceholder.typicode.com/users"
        fetch("https://localhost:44317/api/Sertifikaatit/getExpiringCertificates")
            .then(response => response.json())
            .then(tulos => {
                console.log(tulos);
                // Päivitetään tila
                console.log("Päivitetään tila")
                this.setState( {entryt : tulos });
                console.log("Tila päivitetty");
            });
    }

    // Suoritetaan alussa kerran, ja uudestaan aina kun tila päivitetään
    render(){
        console.log("ApiConnect.render");

        const taulukko = [];
        if (this.state.entryt) {

            const entryt = this.state.entryt;
            console.log("ApiConnect.render --> tila alustettu: " + entryt.length);

            for (let indeksi = 0; indeksi < entryt.length; indeksi++) {
                const entry = entryt[indeksi];
                taulukko.push(<tr key={indeksi}>
                    <td>{entry.certificateId}</td>
                    <td>{entry.sertifikaatinHaltija}</td>
                    <td>{entry.myönnetty}</td>
                    <td>{entry.voimassa}</td>
                    <td>{entry.pätevyys}</td>
                </tr>)
            }
        }

        return <>
             <h1>Löydettyt sertifikaatit</h1>
            <table>
                <thead>
                    <tr>
                        <th>Certificate Id</th>
                        <th>Sertifikaatin haltija</th>
                        <th>Myönnetty</th>
                        <th>Voimassa</th>
                        <th>Pätevyys</th>
                    </tr>
                </thead>
                <tbody>
                    {taulukko}
                </tbody>
            </table>
            </>
    }
}

export default ApiConnect;