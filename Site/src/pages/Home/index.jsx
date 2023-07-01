import style from './style.css'

function Home() {
    return <div>
    <div className="home">
       <header>
            <img src="../src/assets/Logo-4-cut.png" alt="Logo"/>
            <a>Login</a>
       </header>
        <main>
            <div className='home_text'>
                <h1 className='red'>PREPARE-SE</h1>
                <h1 className='red'>PARA MUDAR</h1>
                <h1>PARA MELHOR.</h1>
            </div>
        </main>
    </div>
    </div>
    
}

export default Home