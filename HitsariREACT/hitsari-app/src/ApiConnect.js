import React from 'react';

class ApiConnect extends React.Component{
    
    // Alustetaan tila
    constructor(props) {
        super(props);
        this.state = {sertit: null};

        console.log("ApiConnect.constructor");
    }
    
    // aloitetaan suoritus 
    componentDidMount(){
        console.log("ApiConnect.componentDidMount");

        fetch("https://localhost:44317/api/Sertifikaatit/getExpiringCertificates")
            .then(response => response.json())
            .then(tulos => {
                console.log(tulos);
                // Päivitetään tila
                console.log("Päivitetään sertit")
                this.setState( {sertit : tulos });
                console.log("Tila päivitetty");
            });
    }

    // Suoritetaan alussa kerran, ja uudestaan aina kun tila päivitetään
    render(){
        console.log("ApiConnect.render");

        const taulukko = [];

        if (this.state.sertit) {
            const sertit = this.state.sertit;
            console.log("ApiConnect.render --> tila alustettu, sertit.length: " + sertit.length);

            for (let indeksi = 0; indeksi < sertit.length; indeksi++) {
                const sert = sertit[indeksi];
                taulukko.push(<tr key={indeksi}>
                    <td>{sert.certificateId}</td>
                    <td>{sert.sertifikaatinHaltija}</td>
                    <td>{sert.myönnetty.toString("dd/MM/yyyy")}</td>
                    <td>{sert.voimassa.toString("dd/MM/yyyy")}</td>
                    <td>{sert.pätevyys}</td>
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