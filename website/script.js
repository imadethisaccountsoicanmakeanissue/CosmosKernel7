const textInput = document.querySelector(".text-input")
const submitButton = document.querySelector(".submit")
const imageframe = document.querySelector(".image-frame")

submitButton.addEventListener("click", async () => {
    let inputValue = textInput.value;
    if(inputValue != ""){
        //issue query
		let blob = await getImage({"inputs": inputValue});
		const blobUrl = URL.createObjectURL(blob);
		imageframe.src = blobUrl;
    }
});

async function getImage(data) {
	const response = await fetch(
		"https://api-inference.huggingface.co/models/stabilityai/stable-diffusion-xl-base-1.0",
		{
			headers: { Authorization: "Bearer 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",
            "Content-Type": "application/json"
        },
			method: "POST",
			body: JSON.stringify(data),
		}
	);
	const result = await response.blob();
	return result;
}
