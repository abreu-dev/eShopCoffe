class Constants {
  final String apiUrl;

  const Constants._({required this.apiUrl});

  factory Constants.of() {
    return Constants._local();
  }

  factory Constants._local() {
    return const Constants._(
      apiUrl: 'http://10.0.2.2:5003'
    );
  }

  static final Constants instance = Constants.of();
}