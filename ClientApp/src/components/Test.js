import * as React from "react"
import { useState } from "react"

export const Test = (props) => {

    const [value, setValue] = useState("");

    const handleButtonClick = () => {
        if (value === "" || value==="bye") {
            setValue("hi");
            return;
        }

        if (value === "hi") {
            setValue("bye");
        }

    }

    return (
        <>
            <button onClick={handleButtonClick}>Hello</button>
            <textarea value={value}></textarea>
        </>)
}