import React from 'react'
import Token from '../shared/token'
import { Button } from 'reactstrap';
import '../style/style.css';

class PageUser extends React.Component {

    render() {
        return (
            <div>
                <h1> Bem-vindo -  </h1>
                <Button variant="success" className="space-bottom"> Editar </Button>
                <Button variant="danger" className="space-bottom" onClick={() => Token.logout()}> Sair </Button>
                <div className="grid-user-info"> 
                    <ol>Nome: Gabriel</ol>
                    <ol>Idade: 15 </ol>
                </div>
            </div>
        )
    }
}

export default PageUser;