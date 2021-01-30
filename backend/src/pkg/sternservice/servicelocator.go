package sternservice

// ServiceLocator facilitates communication between services
type ServiceLocator interface {
	GetService(name string) (chan Request, error)
	RegisterService(name string, requestChannel chan Request)
	SimpleRequest(name string, requestContent interface{}) (interface{}, error)
	FireAndForget(name string, requestContent interface{})
	Log(content string)
}

// Request is the wrapper for all request channels
type Request struct {
	Callback chan Response
	Content  interface{}
}

// Response is the wrapper for all response channels
type Response struct {
	err     error
	content interface{}
}

// ServiceUnavailable is an error raised when requested service name doesn't exists
type ServiceUnavailable struct{}

func (*ServiceUnavailable) Error() string {
	return "Service doesn't exist or is not registered yer"
}

// InvalidRequestContentType is raised when the request sent over channel doesn't meet the required type
type InvalidRequestContentType struct{}

func (*InvalidRequestContentType) Error() string {
	return "Request content type doesn't match the required type from the service"
}
