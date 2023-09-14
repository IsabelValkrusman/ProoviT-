import { useEffect, useRef, useState } from 'react';
import './App.css';

function App() {
  const [tooted, setTooted] = useState([]);
  const [pakiautomaadid, setPakiautomaadid] = useState([]);
  const idRef = useRef();
  const nameRef = useRef();
  const priceRef = useRef();
  const isActiveRef = useRef();

  const [fi, setFi] = useState([]);
  const [ee, setEe] = useState([]);
  const [lv, setLv] = useState([]);
  const [lt, setLt] = useState([]);

  
  const [prices, setPrices] = useState([]);
  const [chosenCountry, setChosenCountry] = useState("ee");
  const [start, setStart] = useState("");
  const [end, setEnd] = useState("");
  const startRef = useRef();
  const endRef = useRef();



  useEffect(() => {
    fetch("https://localhost:7254/tooted")
      .then(res => res.json())
      .then(json => setTooted(json));
  }, []);

  useEffect(() => {
    fetch("https://localhost:7254/parcelmachine")
      .then(res => res.json())
      .then(json => setPakiautomaadid(json));
  }, []);

  useEffect(() => {
    fetch("https://localhost:7254/nordpool")
      .then(res => res.json())
      .then(json => {
        setFi(json.data.fi);
        setEe(json.data.ee)
        setLv(json.data.lv)
        setLt(json.data.lt)
      });
  }, []);

  useEffect(() => {
    fetch("https://localhost:7254/nordpool/" + chosenCountry)
      .then(res => res.json())
      .then(json => {
        setPrices(json);
      });
  }, [chosenCountry]);

  useEffect(() => {
    if (start !== "" && end !== "") {
      fetch("https://localhost:7254/nordpool/" + chosenCountry + "/" + start + "/" + end)
        .then(res => res.json())
        .then(json => {
          setPrices(json);
        });
    }
  }, [chosenCountry, start, end]);

  function updateStart() {
    const startIso = new Date(startRef.current.value).toISOString();
    setStart(startIso);
  }

  function updateEnd() {
    const endIso = new Date(endRef.current.value).toISOString();
    setEnd(endIso);
  }


  function kustuta(index) {
    fetch("https://localhost:7254/tooted/kustuta/" + index, {"method": "DELETE"})
      .then(res => res.json())
      .then(json => setTooted(json));
  }

  ////////////////////////
  function lisa() {
    const uusToode = {
      "id": Number(idRef.current.value),
      "name": nameRef.current.value,
      
      "price": Number(priceRef.current.value),
      "isActive": isActiveRef.current.checked
    }
    fetch("https://localhost:7254/tooted/lisa", {"method": "POST", "body": JSON.stringify(uusToode)})
      .then(res => res.json())
      .then(json => setTooted(json));
  }
  ////////////////////////

  function dollariteks() {
    const kurss = 1.1;
    fetch("https://localhost:7254/tooted/hind-dollaritesse/" + kurss, {"method": "PATCH"})
      .then(res => res.json())
      .then(json => setTooted(json));
  }

  return (
    
    <div>
      <label>Nimi</label> <br />
      <input ref={nameRef} type="text" /> <br />
      <label>Hind</label> <br />
      <input ref={priceRef} type="number" /> <br />
      <label>Aktiivne</label> <br />
      <input ref={isActiveRef} type="checkbox" /> <br />
      <button onClick={() => lisa()}>Lisa</button>
    
    {prices.length > 0 && 
    <table style={{marginLeft: "100px"}}>
     
    </table>}
 
  </div>
    
  );
}

export default App;