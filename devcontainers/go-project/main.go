package main

import (
	"encoding/json"
	"fmt"
	"net/http"
	"time"
)

type dateTimeHandler struct{}

type GetDateResponse struct {
	UtcDateTime time.Time `json:"utcDateTime"`
}

func (h *dateTimeHandler) ServeHTTP(w http.ResponseWriter, r *http.Request) {
	response := GetDateResponse{
		UtcDateTime: time.Now().UTC(),
	}

	marshalledResponse, _ := json.Marshal(response)
	w.WriteHeader(http.StatusOK)
	w.Write(marshalledResponse)
}

func main() {
	port := 8080
	mux := http.NewServeMux()
	mux.Handle("/dates/utc", &dateTimeHandler{})

	fmt.Printf("Application works at %v \n", port)
	http.ListenAndServe(fmt.Sprintf(":%v", port), mux)
}
