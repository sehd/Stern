package vault

import (
	"github.com/sehd/Stern/pkg/sternservice"
)

// Service is a stern service for vault that provides per user storage that can save and load info
type Service struct {
	running        bool
	serviceLocator sternservice.ServiceLocator
}

// GetName returns service name
func (s Service) GetName() string {
	return "Vault"
}

// Start creates and returns the listen channel
func (s Service) Start() chan sternservice.Request {
	ch := make(chan sternservice.Request)
	s.running = true
	go s.listenLoop(ch)
	return ch
}

func (s Service) listenLoop(requestChannel chan sternservice.Request) {
	for s.running {
		req, ok := <-requestChannel
		if !ok && s.running {
			logg
		}
	}
}
