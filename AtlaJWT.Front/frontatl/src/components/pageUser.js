import React from 'react'
import Token  from '../shared/token'
import { Button } from 'reactstrap';

class PageUser extends React.Component {

    render(){
        return (
        <div>
        <h1> TESTE </h1>
        <Button variant="danger" className="space-bottom" onClick={() => Token.logout()}> Sair </Button>
        </div>
        )
    }
}

export default PageUser;