#pragma once

#include <map>
#include <set>
#include <string>
#include <tuple>
#include <vector>

#include <krpc/decoder.hpp>
#include <krpc/encoder.hpp>
#include <krpc/error.hpp>
#include <krpc/event.hpp>
#include <krpc/object.hpp>
#include <krpc/service.hpp>
#include <krpc/stream.hpp>

namespace krpc {
namespace services {

class LH : public Service {
 public:
  explicit LH(Client* client);

  double height();

  ::krpc::Stream<double> height_stream();

  ::krpc::schema::ProcedureCall height_call();
};

}  // namespace services

namespace services {

inline LH::LH(Client* client):
  Service(client) {
}

inline double LH::height() {
  std::string _data = this->_client->invoke("LH", "Height");
  double _result;
  decoder::decode(_result, _data, this->_client);
  return _result;
}

inline ::krpc::Stream<double> LH::height_stream() {
  return ::krpc::Stream<double>(this->_client, this->_client->build_call("LH", "Height"));
}

inline ::krpc::schema::ProcedureCall LH::height_call() {
  return this->_client->build_call("LH", "Height");
}
}  // namespace services

}  // namespace krpc

