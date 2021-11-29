import React from 'react'
import BootstrapTable from 'react-bootstrap-table-next';
import paginationFactory from 'react-bootstrap-table2-paginator';
import { Modal, Button } from 'react-bootstrap';
import req from '../services/req';
import Token from '../shared/token'
import ModalEditUser from './modal/modalEditUser';
import ModalInsertUser from './modal/modalInsertUser';
import '../style/style.css'


const columns =
    [{
        dataField: "id", text: "Id"
    },
    {
        dataField: "name", text: "Nome"
    },
    {
        dataField: "age", text: "Idade"
    }]


class ListPage extends React.Component {
    state = {
        showModal: false,
        userpick: [],
        users: [],
        show: false,
        showModalEdit: false,
        showModalInsert: false
    }

    componentDidMount() {
        this.getUserRegistered();
    }

    getUserRegistered = () => {
        req.getAllUser().then(res => {
            const { users } = res.data

            if (res.status === 200) {
                this.setState({ users: res.data })
            }

        }).catch(() => {
            window.location.href = "/"
        })
    }

    componentWillUnmount() {
        this.setState({
            showModalEdit: false,
            showModal: false,
            userpick: [],
            users: [],
            show: false
        })
    }

    closeModalEdit = () => {
        this.setState({
            showModalEdit: !this.state.showModalEdit,
            showModal: !this.state.showModal
        }, this.getUserRegistered())
    }


    closeModalInsert = () => {
        this.setState({
            showModalInsert: !this.state.showModalInsert,
        }, this.getUserRegistered())
    }
    modalShow() {
        const { userpick } = this.state;

        return (
            <Modal show={this.state.showModal}
                onHide={() => this.setState({ showModal: !this.state.showModal })}
            >
                <Modal.Header closeButton>
                    <Modal.Title>Usuário {userpick.name} </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <h1>Informações</h1>
                    <ul>
                        <ol>Id: {userpick.id} </ol>
                        <ol>Name: {userpick.name} </ol>
                        <ol>Price: {userpick.age} </ol>
                    </ul>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="primary" onClick={() => this.setState({ showModalEdit: !this.state.showModalEdit })}>Editar</Button>
                    <Button variant="danger">Deletar</Button>
                </Modal.Footer>
            </Modal>
        )
    }


    render() {
        const { users } = this.state;

        const rowEvents =
        {
            onClick: (e, row) => {
                this.setState({
                    userpick: row,
                    showModal: !this.state.showModal
                })
            }
        }

        return (
            <div>
                <Button variant="success" className="space-bottom" onClick={() => this.setState({ showModalInsert: !this.state.showModalInsert })}> Inserir </Button>
                <Button variant="danger" className="space-bottom" onClick={() => Token.logout()}> Sair </Button>
                {this.state.userpick !== [] ? <div>
                    <div className="grid-style">
                        <BootstrapTable

                            rowStyle={{ backgroundColor: 'grey' }}
                            className="grid-style"
                            keyField="id"
                            data={users}
                            columns={columns}
                            pagination={paginationFactory()}
                            rowEvents={rowEvents}>
                        </BootstrapTable>
                    </div>
                </div> : console.log('teste')}

                {this.state.showModal ? this.modalShow() : null}

                {this.state.showModal ? <ModalEditUser closeModalEdit={() => this.closeModalEdit()} user={this.state.userpick} showModalEdit={this.state.showModalEdit} /> : null}

                {this.state.showModalInsert ? <ModalInsertUser closeModalInsert={() => this.closeModalInsert()} showModalInsert={this.state.showModalInsert} /> : null}
            </div>
        )
    }
}

export default ListPage;