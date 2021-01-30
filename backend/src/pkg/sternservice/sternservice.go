package sternservice

// SternService interface of every service in stern system
type SternService interface {
	GetName() string
	Start() chan Request
}
